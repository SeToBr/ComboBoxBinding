using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp3
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		ObservableCollection<QuestionSet> QuestionSetData = new ObservableCollection<QuestionSet>();

		public MainWindow()
		{
			InitializeComponent();

			QuestionSetData.Add(new QuestionSet { Id = 1, Value = "Question Set 1" });
			QuestionSetData[0].QuestionData.Add(new Question { Id = 1, Value = "1." });
			QuestionSetData[0].QuestionData[0].OptionData.Add(new ComboData { Id = 1, Value = "True" });
			QuestionSetData[0].QuestionData[0].OptionData.Add(new ComboData { Id = 2, Value = "False" });

			QuestionSetData.Add(new QuestionSet { Id = 1, Value = "Question Set 2" });
			QuestionSetData[1].QuestionData.Add(new Question { Id = 1, Value = "1." });
			QuestionSetData[1].QuestionData[0].OptionData.Add(new ComboData { Id = 1, Value = "Yes" });
			QuestionSetData[1].QuestionData[0].OptionData.Add(new ComboData { Id = 2, Value = "No" });
			QuestionSetData[1].QuestionData.Add(new Question { Id = 2, Value = "2." });
			QuestionSetData[1].QuestionData[1].OptionData.Add(new ComboData { Id = 1, Value = "True" });
			QuestionSetData[1].QuestionData[1].OptionData.Add(new ComboData { Id = 2, Value = "False" });

			QuestionSetList.ItemsSource = QuestionSetData;

			//QuestionSetList.DisplayMemberPath = "Value";
			//QuestionSetList.SelectedValuePath = "Id";

		}

		private void QuestionSetList_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			QuestionList.ItemsSource = QuestionSetData[QuestionSetList.SelectedIndex].QuestionData;
			AnswerList.DataContext = null;
			//QuestionList.DisplayMemberPath = "Value";
			//QuestionList.SelectedValuePath = "Id";
		}

		private void QuestionList_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (QuestionList.SelectedIndex != -1)
			{
				//AnswerList.ItemsSource = QuestionSetData[QuestionSetList.SelectedIndex].QuestionData[QuestionList.SelectedIndex].OptionData;
				AnswerList.DataContext = QuestionSetData[QuestionSetList.SelectedIndex].QuestionData[QuestionList.SelectedIndex];

				//AnswerList.DisplayMemberPath = "Value";
				//AnswerList.SelectedValuePath = "Id";
			}
		}


	}

	public class QuestionSet
	{
		public int Id { get; set; }
		public string Value { get; set; }

		public ObservableCollection<Question> QuestionData = new ObservableCollection<Question>();
	}

	public class Question
	{
		public int Id { get; set; }
		public string Value { get; set; }

		public ComboData SelectedOption { get; set; }

		public int SelectedId { get; set; }

		public ObservableCollection<ComboData> OptionData { get; set; } = new ObservableCollection<ComboData>();
	}

	public class ComboData
	{
		public int Id { get; set; }

		public string Value { get; set; }
	}
}
