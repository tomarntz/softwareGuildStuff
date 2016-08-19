using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Data.TagsRepos
{
    public class TagsInMemoryRepo:ITagRepo
    {
        private static readonly List<Tag> _tags;

        static TagsInMemoryRepo()
        {
            if (_tags == null)
            {
                _tags = new List<Tag>();
                _tags.Add(new Tag
                {
                    TagId = 1,
                    TagTitle = "Sword"
                });
                _tags.Add(new Tag
                {
                    TagId = 2,
                    TagTitle = "Ouch"
                });


                _tags.Add(new Tag
                {
                    TagId = 3,
                    TagTitle = "Club"
                });

                _tags.Add(new Tag
                {
                    TagId = 4,
                    TagTitle = "Weapon"
                });

                _tags.Add(new Tag
                {
                    TagId = 5,
                    TagTitle = "Cat"
                });

                _tags.Add(new Tag
                {
                    TagId = 6,
                    TagTitle = "Meow"
                });

                _tags.Add(new Tag()
                {
                    TagId = 7,
                    TagTitle = "Heavy"
                });

            }
        }

        public IEnumerable<string> GetAll()
        {
            return _tags.Select(t => t.TagTitle);
        }

        public Tag Post(Tag tagToAdd)
        {
            bool isNew = true;
            foreach (var tag in _tags)
            {
                if (tag.TagTitle == tagToAdd.TagTitle)
                {
                    isNew = false;
                    tagToAdd.TagId = tag.TagId;
                    break;
                }
            }
            if (isNew)
            {
                tagToAdd.TagId = GetId();
                _tags.Add(tagToAdd);
            }
            return tagToAdd;
        }

        public Tag GetById(int id)
        {
            return _tags.FirstOrDefault(t => t.TagId == id);
        }

        private int GetId()
        {
            int id = _tags.Max(t => t.TagId);
            id++;
            return id;
        }
    }
}
