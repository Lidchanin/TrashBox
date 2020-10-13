using System;

namespace TrashBox.Exceptions
{
    public class AudioPlayerIsNotInitializedException : Exception
    {
        public AudioPlayerIsNotInitializedException(
            string message = "Player isn't initialized. Use AudioService.Load(Stream audioStream)") : base(message)
        {
        }
    }
}