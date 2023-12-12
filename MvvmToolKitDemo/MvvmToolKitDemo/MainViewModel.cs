using CommunityToolkit.Mvvm.ComponentModel;

namespace MvvmToolKitDemo
{
	internal class MainViewModel : ObservableObject
	{
		[ObservableProperty]
		private int left = 0;
	}
}
