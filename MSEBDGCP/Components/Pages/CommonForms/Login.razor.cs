using Radzen;

namespace MSEBDGCP.Components.Pages.CommonForms
{
    public partial class Login
    {
        void OnLogin(LoginArgs args)
        {
            Navigation.NavigateTo("/beneficiary-registration");
        }
    }
}
