namespace Lands.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using Lands.Views;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class LoginViewModel : BaseViewModel//Hereda para refrescar los campos
    {


        //Solo a los que se necesita refrescar hay que definirle propiedad privada.
        #region Attributes
        private string email;
        private string password;
        private bool isRunning;
        private bool isEnabled;
        #endregion

        #region Properties
        public string Email
        {
            //Refresca campos
            get { return email; }
            set { SetValue(ref email, value); }
        }
        public string Password
        {//Refresca campos
            get { return password; }
            set { SetValue(ref password, value); }
        }
        public bool IsRunning
        {//Refresca campos
            get { return isRunning; }
            set { SetValue(ref isRunning, value); }
        }
        public bool IsRemembered
        {
            get;
            set;
        }
        public bool IsEnabled
        {//Refresca campos
            get { return isEnabled; }
            set { SetValue(ref isEnabled, value); }
        }
        #endregion

        #region Constructors
        public LoginViewModel()
        {
            this.IsRemembered = true;
            this.isEnabled = true;
        }
        #endregion

        #region Commands
        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(Login);
            }
        }

        
        private async void Login()
        {
            //Validarion Email
            if (string.IsNullOrEmpty(this.Email))
            {                
                await Application.Current.MainPage.DisplayAlert(
                    "Error", 
                    "You must enter an email.", 
                    "Accept");
                return;
            }
            //Validation Password
            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "You must enter an password.",
                    "Accept");
                return;
            }

            this.IsRunning = true;
            this.isEnabled = false;

            if(this.Email!="abel1000@gmail.com" || this.Password != "123"){
                this.IsRunning = false;
                this.isEnabled = true;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Email or Password Incorrect...",
                    "Accept");
                this.Password = string.Empty;//Limpia el campo 
                return;
            }
            this.IsRunning = false;
            this.isEnabled = true;
            this.Email = string.Empty;
            this.Password = string.Empty;

            MainViewModel.GetInstance().Lands = new LandsViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new LandsPage());
        }
        #endregion       
    }
}
