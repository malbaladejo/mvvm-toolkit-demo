using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MvvmToolKitDemo
{
	[INotifyPropertyChanged]
	internal partial class OtherMainViewModel : OtherViewModel
	{
		[ObservableProperty]
		[NotifyPropertyChangedFor(nameof(Total))]
		[NotifyCanExecuteChangedFor(nameof(ResetCommand))]
		private int left = 0;

		[ObservableProperty]
		[NotifyPropertyChangedFor(nameof(Total))]
		[NotifyCanExecuteChangedFor(nameof(ResetCommand))]
		private int right = 0;

		[ObservableProperty]
		private string messages = "";

		public int Total => this.Left + this.Right;

		[RelayCommand]
		private void IncreaseLeft() => this.Left = this.Left + 1;

		[RelayCommand]
		private void IncreaseRight() => this.Right = this.Right + 1;

		[RelayCommand(CanExecute = nameof(CanReset))]
		private void Reset()
		{
			this.Left = 0;
			this.Right = 0;
		}

		partial void OnLeftChanging(int oldValue, int newValue)
		{
			this.Messages = $"{this.Messages}\nLeft changing from {oldValue} to {newValue}";
		}

		partial void OnLeftChanged(int oldValue, int newValue)
		{
			this.Messages = $"{this.Messages}\nLeft changed from {oldValue} to {newValue}";
		}

		private bool CanReset() => this.Total >= 10;
	}
}
