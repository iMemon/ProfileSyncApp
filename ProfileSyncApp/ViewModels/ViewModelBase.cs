namespace ProfileSyncApp.ViewModels;

public partial class ViewModelBase : ObservableObject
{
    [ObservableProperty]
    public bool _isBusy;
    
    [ObservableProperty]
    public string _title;   
}
