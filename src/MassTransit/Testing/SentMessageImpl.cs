﻿// Copyright 2007-2011 Chris Patterson, Dru Sellers, Travis Smith, et. al.
//  
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use 
// this file except in compliance with the License. You may obtain a copy of the 
// License at 
// 
//     http://www.apache.org/licenses/LICENSE-2.0 
// 
// Unless required by applicable law or agreed to in writing, software distributed 
// under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
// CONDITIONS OF ANY KIND, either express or implied. See the License for the 
// specific language governing permissions and limitations under the License.
namespace MassTransit.Testing
{
	using System;

	public class SentMessageImpl<T> :
		SentMessage<T>
		where T : class
	{
		readonly ISendContext<T> _context;
		Exception _exception;

		public SentMessageImpl(ISendContext<T> context)
		{
			_context = context;
		}

		public ISendContext<T> Context
		{
			get { return _context; }
		}

		public Exception Exception
		{
			get { return _exception; }
		}

		public Type MessageType
		{
			get { return typeof (T); }
		}

		ISendContext SentMessage.Context
		{
			get { return Context; }
		}

		public void SetException(Exception exception)
		{
			_exception = exception;
		}

		public override int GetHashCode()
		{
			return (_context != null ? _context.GetHashCode() : 0);
		}

		public bool Equals(SentMessageImpl<T> other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return Equals(other._context.Message, _context.Message);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != typeof (SentMessageImpl<T>)) return false;
			return Equals((SentMessageImpl<T>) obj);
		}
	}
}