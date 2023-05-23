using DocRanker;
using DocRepresentation;
using Query;

namespace SearchEngineGUI
{
    public partial class HomeForm : Form
    {
        Dictionary<string, List<Token>> mergedIndex;
        AutoCompleteStringCollection searchQueries = new AutoCompleteStringCollection();

        public HomeForm()
        {
            InitializeComponent();
            InitializeIndexer();
            InitializeTextFieldSearch();
        }

        private void InitializeIndexer()
        {
            DocumentRepresentation docRep = DocRepLocalStorage.LoadObjectFromFile();
            mergedIndex = docRep.mergedIndex;
        }

        private void InitializeTextFieldSearch()
        {
            TextBoxQuery.AutoCompleteMode = AutoCompleteMode.Suggest;
            TextBoxQuery.AutoCompleteSource = AutoCompleteSource.CustomSource;

            SearchQuery searchQuery = SearchQueryLocalStorage.LoadObjectFromFile();
            if (searchQuery != null)
            {
                List<string> previousQueries = searchQuery.previousSearchQueries;
                if(previousQueries != null)
                {
                    searchQueries.AddRange(previousQueries.ToArray());
                }
            }

            TextBoxQuery.AutoCompleteCustomSource = searchQueries;

        }

        private void ButtonSearch_Click(object sender, EventArgs e)
        {
            string query = TextBoxQuery.Text;

            Ranker ranker = new Ranker(mergedIndex);
            List<Token> rankedDocuments = ranker.RankQuery(query);

            searchQueries.Add(query);
            SearchQueryLocalStorage.AddQuery(query);

            new ResultsForm(rankedDocuments).Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void TextBoxQuery_TextChanged(object sender, EventArgs e)
        {

        }
    }
}