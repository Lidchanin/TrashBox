using System;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace TrashBox.Helpers
{
    public static class PermissionHelper
    {
        /// <summary>
        /// Check if permission is granted.
        /// </summary>
        /// <typeparam name="TPermission"><see cref="Permissions.BasePermission"/>></typeparam>
        /// <returns>If permission granted</returns>
        public static async Task<bool> IfGrantedAsync<TPermission>()
            where TPermission : Permissions.BasePermission, new()
        {
            var status = await Permissions.CheckStatusAsync<TPermission>();

            return status == PermissionStatus.Granted;
        }

        /// <summary>
        /// Request permission.
        /// </summary>
        /// <typeparam name="TPermission"><see cref="Permissions.BasePermission"/>></typeparam>
        /// <returns>If permission granted</returns>
        public static async Task<bool> RequestAsync<TPermission>()
            where TPermission : Permissions.BasePermission, new()
        {
            var status = await Permissions.RequestAsync<TPermission>();

            return status == PermissionStatus.Granted;
        }

        /// <summary>
        /// If the permission isn't granted, then requested.
        /// </summary>
        /// <typeparam name="TPermission"><see cref="Permissions.BasePermission"/>></typeparam>
        /// <returns>If permission granted</returns>
        public static async Task<bool> CheckAndRequestAsync<TPermission>()
            where TPermission : Permissions.BasePermission, new()
        {
            var status = await Permissions.CheckStatusAsync<TPermission>();

            if (status != PermissionStatus.Granted)
            {
                try
                {
                    status = await Permissions.RequestAsync<TPermission>();
                }
                catch (NullReferenceException)
                {
                    // BUG https://github.com/xamarin/Essentials/issues/1238  
                    // BUG https://github.com/xamarin/Essentials/issues/1325  
                    status = PermissionStatus.Unknown;
                }
            }

            return status == PermissionStatus.Granted;
        }
    }
}