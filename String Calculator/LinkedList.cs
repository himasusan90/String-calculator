using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace String_Calculator
{
	public class LinkedList<T> : ICollection<T>
	{
		public LinkedListNode<T> Head { get; set; }
		public LinkedListNode<T> Tail { get; set; }
		public int NumberOfNodes { get; set; }

		public int Count
		{
			get
			{
				return NumberOfNodes;
			}
		}

		public bool IsReadOnly => throw new NotImplementedException();

		public void Add(T item)
		{
			AddFirst(item);
		}

		public void AddFirst(T value)
		{
			AddFirst(new LinkedListNode<T>(value));
		}
		public void AddFirst(LinkedListNode<T> node)
		{
			LinkedListNode<T> temp = Head;
			Head = node;
			Head.Next = temp;
			NumberOfNodes++;
			if (NumberOfNodes == 1)
			{
				Tail = Head;
			}
		}

		public void AddLast(T value)
		{
			AddLast(new LinkedListNode<T>(value));
		}

		public void AddLast(LinkedListNode<T> node)
		{
			if (NumberOfNodes == 0)
			{
				Head = node;
			}
			else
			{
				Tail.Next = node;
			}

			Tail = node;

			NumberOfNodes++;
		}

		public void Clear()
		{
			throw new NotImplementedException();
		}

		public bool Contains(T item)
		{
			throw new NotImplementedException();
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
			throw new NotImplementedException();
		}

		public IEnumerator GetEnumerator()
		{
			throw new NotImplementedException();
		}

		public bool Remove(T item)
		{
			LinkedListNode<T> previous = null;
			LinkedListNode<T> current = Head;

			while (current != null)
			{
				if (current.Value.Equals(item))
				{
					if (previous != null)
					{
						previous.Next = current.Next;
						if (current.Next == null)
						{
							Tail = previous;
						}

						NumberOfNodes--;
					}
					else
					{
						RemoveFirst();
					}

					return true;
				}

				previous = current;
				current = current.Next;
			}

			return false;
		}

		public void RemoveFirst()
		{
			if (NumberOfNodes != 0)
			{
				Head = Head.Next;
				NumberOfNodes--;

				if (NumberOfNodes == 0)
				{
					Tail = null;
				}
			}
		}

		public void RemoveLast()
		{
			if (NumberOfNodes != 0)
			{
				if (NumberOfNodes == 1)
				{
					Head = null;
					Tail = null;
				}
				else
				{
					LinkedListNode<T> current = Head;
					while (current.Next != Tail)
					{
						current = current.Next;
					}

					current.Next = null;
					Tail = current;
				}

				NumberOfNodes--;
			}
		}
		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			LinkedListNode<T> current = Head;
			while (current != null)
			{
				yield return current.Value;
				current = current.Next;
			}
		}
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<T>)this).GetEnumerator();
		}

		public void PrintList()
		{
			LinkedListNode<T> current = Head;
			while (current != null)
			{
				Console.WriteLine(current.Value);
				current = current.Next;
			}
		}
		public override string ToString()
		{
			return base.ToString();
		}
	}
	public class LinkedListNode<T>
	{
		public T Value { get; set; }
		public LinkedListNode<T> Next { get; set; }
		public LinkedListNode(T value)
		{
			Value = value;
		}
	}
}
