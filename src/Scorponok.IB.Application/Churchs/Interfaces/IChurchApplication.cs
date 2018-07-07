using System;
using Scorponok.IB.Application.Churchs.Views;

namespace Scorponok.IB.Application.Churchs.Interfaces
{
    public interface IChurchApplication : IDisposable
    {
        void RegisterChurch(RegisterChurchViewModel view);

        void DeletedChurch(ChurchDeletedViewModel view);

        void UpdatedChurch(ChurchUpdatedViewModel view);
    }
}