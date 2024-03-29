// Copyright (c) .NET Core Community. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using DotNetCore.CAP.Internal;

namespace DotNetCore.CAP.SqlServer.Diagnostics;

public class DiagnosticRegister : IProcessingServer
{
    private readonly DiagnosticProcessorObserver _diagnosticProcessorObserver;

    public DiagnosticRegister(DiagnosticProcessorObserver diagnosticProcessorObserver)
    {
        _diagnosticProcessorObserver = diagnosticProcessorObserver;
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }

    public Task Start(CancellationToken stoppingToken)
    {
        DiagnosticListener.AllListeners.Subscribe(_diagnosticProcessorObserver);
        return Task.CompletedTask;
    }
}