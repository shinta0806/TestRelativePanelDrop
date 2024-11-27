using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.UI.Xaml;
using Windows.ApplicationModel.DataTransfer;
using Windows.Storage;

namespace TestRelativePanelDrop.ViewModels;

public partial class MainViewModel : ObservableRecipient
{
	public MainViewModel()
	{
	}

	private String? _path;
	public String? Path
	{
		get => _path;
		set => SetProperty(ref _path, value);
	}

	public void DragOver(Object _, DragEventArgs args)
	{
		try
		{
			if (!args.DataView.Contains(StandardDataFormats.StorageItems))
			{
				return;
			}
			args.Handled = true;
			args.AcceptedOperation = DataPackageOperation.Copy;
		}
		catch (Exception)
		{
		}
	}

	public async void Drop(Object _, DragEventArgs args)
	{
		try
		{
			if (!args.DataView.Contains(StandardDataFormats.StorageItems))
			{
				return;
			}

			args.Handled = true;
			IReadOnlyList<IStorageItem> storageItems = await args.DataView.GetStorageItemsAsync();
			foreach (IStorageItem storageItem in storageItems)
			{
				Path = storageItem.Path;
			}
		}
		catch (Exception)
		{
		}
	}

}
