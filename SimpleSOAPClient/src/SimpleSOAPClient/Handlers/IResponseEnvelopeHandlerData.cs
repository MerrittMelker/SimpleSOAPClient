﻿namespace SimpleSOAPClient.Handlers
{
    using Models;

    /// <summary>
    /// Represents the SOAP Envelope response handler data.
    /// </summary>
    public interface IResponseEnvelopeHandlerData : IHandlerData
    {
        /// <summary>
        /// The current SOAP Envelope response
        /// </summary>
        SoapEnvelope Envelope { get; }
    }
}