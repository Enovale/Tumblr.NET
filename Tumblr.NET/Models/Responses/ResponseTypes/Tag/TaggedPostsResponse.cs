using System.Collections;
using TumblrNET.Models.Common.PostTypes;

namespace TumblrNET.Models.Responses.ResponseTypes.TagResponses
{
    public class TaggedPostsResponse : Response, IList<Post>
    {
        private readonly List<Post> _list = new();
        
        public IEnumerator<Post> GetEnumerator() => _list.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public void Add(Post item) => _list.Add(item);

        public void Clear() => _list.Clear();

        public bool Contains(Post item) => _list.Contains(item);

        public void CopyTo(Post[] array, int arrayIndex) => _list.CopyTo(array, arrayIndex);

        public bool Remove(Post item) => _list.Remove(item);

        public int Count => _list.Count;
        public bool IsReadOnly => false;
        
        public int IndexOf(Post item) => _list.IndexOf(item);

        public void Insert(int index, Post item) => _list.Insert(index, item);

        public void RemoveAt(int index) => _list.RemoveAt(index);

        // Hide Linq extension because we can do it directly :)
        public List<Post> ToList() => _list;

        public Post this[int index]
        {
            get => _list[index];
            set => _list[index] = value;
        }
    }
}