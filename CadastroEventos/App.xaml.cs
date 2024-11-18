using CadastroEventos.Views;

namespace CadastroEventos
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new CadastroPage());
        }
    }
}
