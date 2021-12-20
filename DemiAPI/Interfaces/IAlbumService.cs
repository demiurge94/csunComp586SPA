using DemiAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemiAPI.Interfaces
{
    public interface IAlbumService
    {
        public Task<ICollection<AlbumVm>> GetAlbums(int artistId);
    }
}
