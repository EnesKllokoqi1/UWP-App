using Components;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWP_App
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public XamlUICommand ChangeFirstNameCommand;
        public XamlUICommand ChangeLastNameCommand;
        public XamlUICommand ChangeIdCommand;
        public XamlUICommand ChangeGenderCommand;
        public XamlUICommand ChangeAnnualSalaryCommand;



        ObservableCollection<WorkersViewModel> _workersOC;
        public MainPage()
        {
            this.InitializeComponent();
            Workers workers = new Workers();
            _workersOC = workers.GetWorkers();
            WorkersList.ItemsSource=_workersOC;
            ChangeFirstNameCommand = new XamlUICommand();
            ChangeLastNameCommand = new XamlUICommand();
            ChangeIdCommand = new XamlUICommand();
            ChangeGenderCommand = new XamlUICommand();
            ChangeAnnualSalaryCommand = new XamlUICommand();
            ChangeIdCommand.ExecuteRequested += ChangeIdCommand_ExecuteRequested;
            ChangeFirstNameCommand.ExecuteRequested += ChangeFirstNameCommand_ExecuteRequested;
            ChangeLastNameCommand.ExecuteRequested += ChangeLastNameCommand_ExecuteRequested;
            ChangeGenderCommand.ExecuteRequested += ChangeGenderCommand_ExecuteRequested;
            ChangeAnnualSalaryCommand.ExecuteRequested += ChangeAnnualSalaryCommand_ExecuteRequested;
            btnThankYou.Click += BtnThankYou_Click;
            btnDateTime.Click += BtnDateTime_Click;
        }

        private async void BtnDateTime_Click(object sender, RoutedEventArgs e)
        {
            await SpeakAsync($"Current Date Time,: {DateTime.Now}");

        }

        private async void ChangeAnnualSalaryCommand_ExecuteRequested(XamlUICommand sender, ExecuteRequestedEventArgs args)
        {
            ListView list =(ListView)args.Parameter;
            if (list.SelectedIndex != -1)
            {
                if (int.TryParse(txtAnnualSalary.Text, out int salary))
                {
                    await SpeakAsync($"Changing AnnualSalary from {_workersOC[list.SelectedIndex].AnnualSalary},to {salary}");
                    _workersOC[list.SelectedIndex].AnnualSalary = salary;
                }
                else
                {
                    await SpeakAsync($"Please enter a valid number");
                }
            }

        }

        private async void ChangeGenderCommand_ExecuteRequested(XamlUICommand sender, ExecuteRequestedEventArgs args)
        {
            ListView list = (ListView)args.Parameter;
            if (list.SelectedIndex != -1)
            {
                if (char.TryParse(txtGender.Text, out char gender))
                {
                    await SpeakAsync($"Changing Gender from {_workersOC[list.SelectedIndex].Gender},to {gender}");
                    _workersOC[list.SelectedIndex].Gender = gender;
                }
                else
                {
                    await SpeakAsync($"Please enter a valid Gender");
                }
            }
        }

        private async void ChangeLastNameCommand_ExecuteRequested(XamlUICommand sender, ExecuteRequestedEventArgs args)
        {
            ListView listView = (ListView)args.Parameter;
            if (listView.SelectedIndex != -1)
            {
                await SpeakAsync($"Changing last name from {_workersOC[listView.SelectedIndex].LastName},to {txtLastName.Text}");
                _workersOC[listView.SelectedIndex].LastName = txtLastName.Text;
            }
            else
            {
                await SpeakAsync($"Please enter a valid Last Name");
            }
        }

        private async void ChangeIdCommand_ExecuteRequested(XamlUICommand sender, ExecuteRequestedEventArgs args)
        {
            ListView listView =(ListView)args.Parameter;
            if (listView.SelectedIndex != -1)
            {
                if(int.TryParse(txtId.Text,out int Id))
                {
                    await SpeakAsync($"Changing Id from {_workersOC[listView.SelectedIndex].Id}, to {Id}");
                    _workersOC[listView.SelectedIndex].Id = Id;
                }
                else
                {
                    await SpeakAsync($"Please enter a valid Id");
                }
            }
        }

        private async void  BtnThankYou_Click(object sender, RoutedEventArgs e)
        {
            await SpeakAsync($"Thank you and take care");
        }

        private async void ChangeFirstNameCommand_ExecuteRequested(XamlUICommand sender, ExecuteRequestedEventArgs args)
        {
            ListView lv = (ListView)args.Parameter;
            if (lv.SelectedIndex != -1)
            {
                await SpeakAsync($"Changing first name from {_workersOC[lv.SelectedIndex].FirstName} to {txtFirstName.Text}");
                _workersOC[lv.SelectedIndex].FirstName = txtFirstName.Text;
            }
            else
            {
                await SpeakAsync($"Please enter a valid number");
            }
        }
        private async Task SpeakAsync(string text)
        {

            MediaElement mediaElement = new MediaElement();
            var synth = new Windows.Media.SpeechSynthesis.SpeechSynthesizer();
            Windows.Media.SpeechSynthesis.SpeechSynthesisStream stream = await synth.SynthesizeTextToStreamAsync(text);
            mediaElement.SetSource(stream, stream.ContentType);

        }

       
    }
}
