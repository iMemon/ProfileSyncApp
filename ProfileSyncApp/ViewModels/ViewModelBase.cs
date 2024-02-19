namespace ProfileSyncApp.ViewModels;

public abstract partial class ViewModelBase : ObservableObject
{
    [ObservableProperty]
    public bool _isBusy;
    
    [ObservableProperty]
    public string _title;   
}
