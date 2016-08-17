﻿// Copyright (c) 2002-2016 "Neo Technology,"
// Network Engine for Objects in Lund AB [http://neotechnology.com]
// 
// This file is part of Neo4j.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
using System;
using System.Collections.Generic;
using Neo4j.Driver.Internal.Result;

namespace Neo4j.Driver.Internal.Connector
{
    internal interface IConnection : IDisposable
    {
        void Sync();
        void SyncRun();
        void Run(IResultBuilder resultBuilder, string statement, IDictionary<string, object> parameters=null);
        void PullAll(IResultBuilder resultBuilder);
        void DiscardAll();
        void Reset();

        /// <summary>
        /// Return true if the underlying socket connection is till open, otherwise false.
        /// </summary>
        bool IsOpen { get; }
        /// <summary>
        /// Return true if unrecoverable error has been received on this connection, otherwise false.
        /// </summary>
        bool HasUnrecoverableError { get; }
        /// <summary>
        /// Return true if more statements could be run on this connection, otherwise false.
        /// </summary>
        bool IsHealthy { get; }
        /// <summary>
        /// Close and release related resources
        /// </summary>
        void Close();
    }
}