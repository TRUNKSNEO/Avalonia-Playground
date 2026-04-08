using MyAvalonia.Data;
using MyAvalonia.ViewModels;
using System;

namespace MyAvalonia.Factory
{
	public class PageFactory
	{
		private readonly Func<ApplicationPageNames, PageViewModel> _factory;

		public PageFactory(Func<ApplicationPageNames, PageViewModel> factory)
		{
			_factory = factory;
		}

		public PageViewModel GetPage(ApplicationPageNames pageName) => _factory.Invoke(pageName);

	}
}
