using System.Collections;
using TumblrNET.Models.Common.Post;

namespace TumblrNET.Models.Responses.ResponseTypes.Tag
{
    public class TaggedPostsResponse : Response, IList<PostInfo>
    {
        private readonly List<PostInfo> _list = new();
        
        public IEnumerator<PostInfo> GetEnumerator() => _list.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public void Add(PostInfo item) => _list.Add(item);

        public void Clear() => _list.Clear();

        public bool Contains(PostInfo item) => _list.Contains(item);

        public void CopyTo(PostInfo[] array, int arrayIndex) => _list.CopyTo(array, arrayIndex);

        public bool Remove(PostInfo item) => _list.Remove(item);

        public int Count => _list.Count;
        public bool IsReadOnly => false;
        
        public int IndexOf(PostInfo item) => _list.IndexOf(item);

        public void Insert(int index, PostInfo item) => _list.Insert(index, item);

        public void RemoveAt(int index) => _list.RemoveAt(index);

        // Hide Linq extension because we can do it directly :)
        public List<PostInfo> ToList() => _list;

        public PostInfo this[int index]
        {
            get => _list[index];
            set => _list[index] = value;
        }
    }
}