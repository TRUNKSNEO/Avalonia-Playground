using CommunityToolkit.Mvvm.ComponentModel;
using MyAvalonia.Data;

namespace MyAvalonia.ViewModels
{
	public partial class PageViewModel : ViewModelBase
	{
		[ObservableProperty]
		private ApplicationPageNames _pageName;
	}
}
