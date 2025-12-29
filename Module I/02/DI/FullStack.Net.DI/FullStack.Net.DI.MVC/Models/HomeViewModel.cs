namespace FullStack.Net.DI.MVC.Models
{
    public class HomeViewModel
    {
        public HomeViewModel()
        {
            ControllerData = new GuidViewModel();
            ClientData = new GuidViewModel();
        }
        public GuidViewModel ControllerData { get; set; }
        public GuidViewModel ClientData { get; set; }
    }
}
