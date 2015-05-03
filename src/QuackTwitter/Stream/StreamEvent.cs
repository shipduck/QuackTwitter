using System;

namespace QuackTwitter
{
	public class StreamEvent : EventArgs
	{
		public enum EventType {
			Status,
			Statuses,
			Closed
		};

		public EventType type { get; private set; }
		public object data {get; private set; }

		public StreamEvent(EventType type, object data)
		{
			this.type = type;
			this.data = data;
		}
	}
}

