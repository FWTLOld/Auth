﻿namespace GitGud.Web.Core.Providers
{
    public interface IUserProvider
    {
        int CurrentUserId { get; }

        bool IsAuthenticated { get; }
    }
}