﻿using DirectoryDomain.ViewModels;
using DirectoryServiceLib.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Delta.Controllers.Directories
{
    public class DirectoryItemController : Controller
    {
        private readonly IDirectoryService _directoryService;
        private readonly DirectoryItemViewModel _viewModel;

        public DirectoryItemController(IDirectoryService directoryService)
        {
            _directoryService = directoryService;
            _viewModel = new DirectoryItemViewModel();
        }

        public IActionResult Index(Guid directoryListId)
        {
            var directories = _directoryService.GetDirectoryEntities(directoryListId);
            return View();
        }
    }
}
