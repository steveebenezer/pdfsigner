using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Platform;
using System;
using System.IO;
using System.Threading.Tasks;

namespace PdfSigner.Views
{
    public partial class Dashboard : UserControl
    {
        private Button _inputSourceButton;
        private Button _outputDestinationButton;

        public Dashboard()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
#pragma warning disable CS8601 // Possible null reference assignment.
            _inputSourceButton = this.FindControl<Button>("InputSourceButton");
            _outputDestinationButton = this.FindControl<Button>("OutputDestinationButton");
#pragma warning restore CS8601 // Possible null reference assignment.

#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument.
            _inputSourceButton.Click += async (sender, e) => await OnInputSourceButtonClick(sender, e);
            _outputDestinationButton.Click += async (sender, e) => await OnOutputDestinationButtonClick(sender, e);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning restore CS8604 // Possible null reference argument.

            AvaloniaXamlLoader.Load(this);
        }

        private async Task OnInputSourceButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                await HandleFolderButtonClick(_inputSourceButton);
            }
            catch (Exception err)
            {
                Console.WriteLine($"Error: {err.Message}");
            }
        }

        private async Task OnOutputDestinationButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                await HandleFolderButtonClick(_outputDestinationButton);
            }
            catch (Exception err)
            {
                Console.WriteLine($"Error: {err.Message}");
            }
        }

        private async Task HandleFolderButtonClick(Button button)
        {
            var window = (Window)this.VisualRoot;

            var selectedFolder = await OpenFolderDialogAsync(window, $"Select a folder for {button.Name}");

            if (!string.IsNullOrWhiteSpace(selectedFolder))
            {
                Console.WriteLine($"Selected folder for {button.Name}: {selectedFolder}");
                // Perform actions with the selected folder path
            }
            // await Task.Run(() => 
            // {
            //     Console.WriteLine("Hello");
            // });
        }

        private static async Task<string> OpenFolderDialogAsync(Window window, string title)
        {
            var dialog = new OpenFolderDialog
            {
                Title = title,
                Directory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            };

            return await dialog.ShowAsync(window);
        }
    }
}
