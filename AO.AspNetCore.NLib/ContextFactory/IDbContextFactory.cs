using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AO.AspNetCore.NLib.ContextFactory
{
    /// <summary>
    /// Creates instance of specific DbContext
    /// </summary>
    public interface IDbContextFactory //: IDisposable  //NOTE: Since UnitOfWork is disposable I am not sure if context factory has to be also...
    {
        DbContext GetDbContext();
    }
}
