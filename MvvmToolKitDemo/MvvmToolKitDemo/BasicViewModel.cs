using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;

namespace MvvmToolKitDemo
{
	internal partial class BasicViewModel : ObservableObject
	{
		private int left = 0;
		private int right = 0;
		private string messages = "";
		private RelayCommand increaseLeftCommand;
		private RelayCommand increaseRightCommand;
		private RelayCommand resetCommand;

		public BasicViewModel()
		{
			this.increaseLeftCommand = new RelayCommand(this.IncreaseLeft);
			this.increaseRightCommand = new RelayCommand(this.IncreaseRight);
			this.resetCommand = new RelayCommand(this.Reset, this.CanReset);
		}

		public int Total => this.Left + this.Right;

		private void IncreaseLeft() => this.Left = this.Left + 1;

		private void IncreaseRight() => this.Right = this.Right + 1;

		private void Reset()
		{
			this.Left = 0;
			this.Right = 0;
		}

		private void OnLeftChanging(int oldValue, int newValue)
		{
			this.Messages = $"{this.Messages}\nLeft changing from {oldValue} to {newValue}";
		}

		private void OnLeftChanged(int oldValue, int newValue)
		{
			this.Messages = $"{this.Messages}\nLeft changed from {oldValue} to {newValue}";
		}

		private bool CanReset() => this.Total >= 10;

		public int Left
		{
			get => this.left;
			set
			{
				var oldValue = this.left;
				this.OnLeftChanging(oldValue, value);

				if (SetProperty(ref this.left, value))
				{
					this.OnLeftChanged(oldValue, value);
					this.OnPropertyChanged(nameof(this.Total));
					this.resetCommand.NotifyCanExecuteChanged();
				}
			}
		}

		public int Right
		{
			get => this.right;
			set
			{
				if (SetProperty(ref this.right, value))
				{
					this.OnPropertyChanged(nameof(this.Total));
					this.resetCommand.NotifyCanExecuteChanged();
				}
			}
		}

		public string Messages
		{
			get => this.messages;
			set => SetProperty(ref this.messages, value);
		}

		public ICommand IncreaseLeftCommand => this.increaseLeftCommand;

		public ICommand IncreaseRightCommand => this.increaseRightCommand;

		public ICommand ResetCommand => this.resetCommand;
	}
}
