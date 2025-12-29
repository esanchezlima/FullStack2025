using Library.Service.Domain.Authors.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Service.Infrastructure.Persistence.Contexts
{
    public partial class LibraryContext : DbContext
    {
        public void EnsureSeedDataForContext()
        {
            Database.EnsureDeleted();
            Database.Migrate();
            SaveChanges();

            List<Author> authors = new List<Author>()
            {
                new Author()
                {
                    AuthorId = new Guid("25320c5e-f58a-4b1f-b63a-8ee07a840bdf"),
                    FirstName = "Stephen",
                    LastName = "King",
                    Genre = "Horror",
                    DateOfBirth = new DateTimeOffset(new DateTime(1947, 9, 21)),
                    Books = new List<Book>()
                    {
                        new Book()
                        {
                            BookId = new Guid("c7ba6add-09c4-45f8-8dd0-eaca221e5d93"),
                            Title = "The Shining",
                            Description = "The Shining is a horror novel by American author Stephen King. Published in 1977, it is King's third published novel and first hardback bestseller: the success of the book firmly established King as a preeminent author in the horror genre. "
                        },
                        new Book()
                        {
                            BookId = new Guid("a3749477-f823-4124-aa4a-fc9ad5e79cd6"),
                            Title = "Misery",
                            Description = "Misery is a 1987 psychological horror novel by Stephen King. This novel was nominated for the World Fantasy Award for Best Novel in 1988, and was later made into a Hollywood film and an off-Broadway play of the same name."
                        },
                        new Book()
                        {
                            BookId = new Guid("70a1f9b9-0a37-4c1a-99b1-c7709fc64167"),
                            Title = "It",
                            Description = "It is a 1986 horror novel by American author Stephen King. The story follows the exploits of seven children as they are terrorized by the eponymous being, which exploits the fears and phobias of its victims in order to disguise itself while hunting its prey. 'It' primarily appears in the form of a clown in order to attract its preferred prey of young children."
                        },
                        new Book()
                         {
                             BookId = new Guid("60188a2b-2784-4fc4-8df8-8919ff838b0b"),
                             Title = "The Stand",
                             Description = "The Stand is a post-apocalyptic horror/fantasy novel by American author Stephen King. It expands upon the scenario of his earlier short story 'Night Surf' and outlines the total breakdown of society after the accidental release of a strain of influenza that had been modified for biological warfare causes an apocalyptic pandemic which kills off the majority of the world's human population."
                         }
                    }
                },
                new Author()
                {
                    AuthorId = new Guid("76053df4-6687-4353-8937-b45556748abe"),
                    FirstName = "George",
                    LastName = "RR Martin",
                    Genre = "Fantasy",
                    DateOfBirth = new DateTimeOffset(new DateTime(1948, 9, 20)),
                    Books = new List<Book>()
                    {
                        new Book()
                        {
                            BookId = new Guid("447eb762-95e9-4c31-95e1-b20053fbe215"),
                            Title = "A Game of Thrones",
                            Description = "A Game of Thrones is the first novel in A Song of Ice and Fire, a series of fantasy novels by American author George R. R. Martin. It was first published on August 1, 1996."
                        },
                        new Book()
                        {
                            BookId = new Guid("bc4c35c3-3857-4250-9449-155fcf5109ec"),
                            Title = "The Winds of Winter",
                            Description = "Forthcoming 6th novel in A Song of Ice and Fire."
                        },
                        new Book()
                        {
                            BookId = new Guid("09af5a52-9421-44e8-a2bb-a6b9ccbc8239"),
                            Title = "A Dance with Dragons",
                            Description = "A Dance with Dragons is the fifth of seven planned novels in the epic fantasy series A Song of Ice and Fire by American author George R. R. Martin."
                        }
                    }
                },
                new Author()
                {
                    AuthorId = new Guid("412c3012-d891-4f5e-9613-ff7aa63e6bb3"),
                    FirstName = "Neil",
                    LastName = "Gaiman",
                    Genre = "Fantasy",
                    DateOfBirth = new DateTimeOffset(new DateTime(1960, 11, 10)),
                    Books = new List<Book>()
                    {
                        new Book()
                        {
                            BookId = new Guid("9edf91ee-ab77-4521-a402-5f188bc0c577"),
                            Title = "American Gods",
                            Description = "American Gods is a Hugo and Nebula Award-winning novel by English author Neil Gaiman. The novel is a blend of Americana, fantasy, and various strands of ancient and modern mythology, all centering on the mysterious and taciturn Shadow."
                        }
                    }
                },
                new Author()
                {
                    AuthorId= new Guid("578359b7-1967-41d6-8b87-64ab7605587e"),
                    FirstName = "Tom",
                    LastName = "Lanoye",
                    Genre = "Various",
                    DateOfBirth = new DateTimeOffset(new DateTime(1958, 8, 27)),
                    Books = new List<Book>()
                    {
                        new Book()
                        {
                            BookId = new Guid("01457142-358f-495f-aafa-fb23de3d67e9"),
                            Title = "Speechless",
                            Description = "Good-natured and often humorous, Speechless is at times a 'song of curses', as Lanoye describes the conflicts with his beloved diva of a mother and her brave struggle with decline and death."
                        }
                    }
                },
                new Author()
                {
                    AuthorId = new Guid("f74d6899-9ed2-4137-9876-66b070553f8f"),
                    FirstName = "Douglas",
                    LastName = "Adams",
                    Genre = "Science fiction",
                    DateOfBirth = new DateTimeOffset(new DateTime(1952, 3, 11)),
                    Books = new List<Book>()
                    {
                        new Book()
                        {
                            BookId = new Guid("e57b605f-8b3c-4089-b672-6ce9e6d6c23f"),
                            Title = "The Hitchhiker's Guide to the Galaxy",
                            Description = "The Hitchhiker's Guide to the Galaxy is the first of five books in the Hitchhiker's Guide to the Galaxy comedy science fiction 'trilogy' by Douglas Adams."
                        }
                    }
                },
                new Author()
                {
                    AuthorId = new Guid("a1da1d8e-1988-4634-b538-a01709477b77"),
                    FirstName = "Jens",
                    LastName = "Lapidus",
                    Genre = "Thriller",
                    DateOfBirth = new DateTimeOffset(new DateTime(1974, 5, 24)),
                    Books = new List<Book>()
                    {
                        new Book()
                        {
                            BookId = new Guid("1325360c-8253-473a-a20f-55c269c20407"),
                            Title = "Easy Money",
                            Description = "Easy Money or Snabba cash is a novel from 2006 by Jens Lapidus. It has been a success in term of sales, and the paperback was the fourth best seller of Swedish novels in 2007."
                        }
                    }
                },
                new Author()
                {
                    AuthorId = new Guid("97bf7300-049e-498c-b152-d0accf6f882d"),
                    FirstName = "Stephen",
                    LastName = "Fry",
                    Genre = "Various",
                    DateOfBirth = new DateTimeOffset(new DateTime(1957, 8, 24)),
                    Books = new List<Book>()
                    {
                        new Book()
                        {
                            BookId = new Guid("1eca5a15-ee1f-4fd5-a52a-943f72d37c2d"),
                            Title = "The Liar",
                            Description = "The Liar is a novel by British writer and actor Stephen Fry, first published in 1991 by Hutchinson. It is a humorous coming-of-age story."
                        }
                    }
                },
                new Author()
                {
                    AuthorId = new Guid("f5b38e4a-8f83-4a8e-94fb-e7fef7db8d33"),
                    FirstName = "James",
                    LastName = "Elroy",
                    Genre = "Crime",
                    DateOfBirth = new DateTimeOffset(new DateTime(1948, 3, 3)),
                    Books = new List<Book>()
                    {
                        new Book()
                        {
                            BookId = new Guid("dfa2699d-4c66-45be-aa95-2b3ca9a9d25f"),
                            Title = "L.A. Confidential",
                            Description = "L.A. Confidential is a 1990 crime fiction novel by James Ellroy, and the third of his L.A. Quartet series. James Ellroy dedicated L.A. Confidential 'to Mary Doherty Ellroy'."
                        }
                    }
                },
                new Author()
                {
                    AuthorId = new Guid("91b3f062-cc37-489d-a9b9-6875bde8531f"),
                    FirstName = "Roger",
                    LastName = "Hargreaves",
                    Genre = "Children",
                    DateOfBirth = new DateTimeOffset(new DateTime(1935, 5, 9)),
                    Books = new List<Book>()
                    {
                        new Book()
                        {
                            BookId = new Guid("94a0c4b0-073b-483d-b15b-fa34ad20c3a3"),
                            Title = "Mr. Tickle",
                            Description = "Mr. Tickle is a mischievous character with extraordinarily long arms, using them to tickle everyone in his path."
                        }
                    }
                },
                new Author()
                {
                    AuthorId = new Guid("d5f7da73-3768-41d1-b5d4-1b58b6ba7d93"),
                    FirstName = "J.K.",
                    LastName = "Rowling",
                    Genre = "Fantasy",
                    DateOfBirth = new DateTimeOffset(new DateTime(1965, 7, 31)),
                    Books = new List<Book>()
                    {
                        new Book()
                        {
                            BookId = new Guid("aaf7da73-2768-41d1-b5d4-1b58b6ba7a23"),
                            Title = "Harry Potter and the Philosopher's Stone",
                            Description = "The first book in the Harry Potter series, where young Harry discovers he's a wizard."
                        },
                        new Book()
                        {
                            BookId = new Guid("b5e6fa73-8768-41d1-b5d4-1b58b6ba7b34"),
                            Title = "Harry Potter and the Chamber of Secrets",
                            Description = "The second book in the series, where Harry faces challenges in his second year at Hogwarts."
                        }
                    }
                },
                new Author()
                {
                    AuthorId = new Guid("e6d8ba84-5869-52a1-a5d5-2c58c7ca8d94"),
                    FirstName = "Agatha",
                    LastName = "Christie",
                    Genre = "Mystery",
                    DateOfBirth = new DateTimeOffset(new DateTime(1890, 9, 15)),
                    Books = new List<Book>()
                    {
                        new Book()
                        {
                            BookId = new Guid("c3d9ea84-5869-52a1-a5d5-2c58c7ca8c45"),
                            Title = "Murder on the Orient Express",
                            Description = "A famous detective novel where Hercule Poirot solves a murder on a snowbound train."
                        },
                        new Book()
                        {
                            BookId = new Guid("d4e0fb95-696a-63b2-b6e6-3d69d8db9e56"),
                            Title = "The Murder of Roger Ackroyd",
                            Description = "One of Christie's most famous works, with a groundbreaking twist ending."
                        }
                    }
                },
                new Author()
                {
                    AuthorId = new Guid("8ea8a3d0-4690-468f-b776-cd62362d5273"),
                    FirstName = "Isabel",
                    LastName = "Allende",
                    Genre = "Historical Fiction",
                    DateOfBirth = new DateTimeOffset(new DateTime(1942, 8, 2)),
                    Books = new List<Book>()
                    {
                        new Book()
                        {
                            BookId = new Guid("3a25d35e-c059-4989-a491-0e1cfcaf7f09"),
                            Title = "The House of the Spirits",
                            Description = "A multi-generational family saga that spans from the early 20th century to the 1973 Chilean coup d'état."
                        }
                    }
                },
                new Author()
                {
                    AuthorId = new Guid("7d20ad08-1796-43d0-aec3-c8be954bf055"),
                    FirstName = "Orhan",
                    LastName = "Pamuk",
                    Genre = "Novel",
                    DateOfBirth = new DateTimeOffset(new DateTime(1952, 6, 7)),
                    Books = new List<Book>()
                    {
                        new Book()
                        {
                            BookId = new Guid("0a4cd20b-4b8f-4c0c-bb94-fa70d79551c3"),
                            Title = "My Name is Red",
                            Description = "A philosophical mystery set in 16th-century Istanbul, revolving around the miniaturists of the Ottoman Empire."
                        },
                        new Book()
                        {
                            BookId = new Guid("a698370e-afcd-4d2a-b3bb-de0c6a947add"),
                            Title = "Snow",
                            Description = "A novel exploring the clash between Western and Eastern cultural values in modern Turkey."
                        }
                    }
                },
                new Author()
                {
                    AuthorId = new Guid("9dfd0568-4ae8-4ea9-a2a2-a72e862029a7"),
                    FirstName = "Gabriel",
                    LastName = "García Márquez",
                    Genre = "Magical Realism",
                    DateOfBirth = new DateTimeOffset(new DateTime(1927, 3, 6)),
                    Books = new List<Book>()
                    {
                        new Book()
                        {
                            BookId = new Guid("be6b273c-a561-43c8-94c0-2819f3c7d7b0"),
                            Title = "One Hundred Years of Solitude",
                            Description = "The multi-generational story of the Buendía family in the fictional town of Macondo, Colombia."
                        },
                        new Book()
                        {
                            BookId = new Guid("7583af2b-dffb-4828-aecb-934e19caeb26"),
                            Title = "Love in the Time of Cholera",
                            Description = "A novel exploring love in all its forms, centered around the enduring passion between Florentino Ariza and Fermina Daza."
                        }
                    }
                },
                new Author()
                {
                    AuthorId = new Guid("304f4ff8-10ed-4203-9c42-b9b1c0f617a2"),
                    FirstName = "Jane",
                    LastName = "Austen",
                    Genre = "Romance",
                    DateOfBirth = new DateTimeOffset(new DateTime(1775, 12, 16)),
                    Books = new List<Book>()
                    {
                        new Book()
                        {
                            BookId = new Guid("ff8d82db-6ada-40e8-9d2c-2a721411d373"),
                            Title = "Pride and Prejudice",
                            Description = "A romantic novel centered on Elizabeth Bennet and her relationship with the proud Mr. Darcy."
                        },
                        new Book()
                        {
                            BookId = new Guid("12962c97-c48e-4775-92db-689d13bf6e50"),
                            Title = "Sense and Sensibility",
                            Description = "The story of the Dashwood sisters, Elinor and Marianne, and their contrasting experiences of love and heartbreak."
                        }
                    }
                },
                new Author()
                {
                    AuthorId = new Guid("0537c16a-c904-4084-9c55-8d0a3708d44e"),
                    FirstName = "Ernest",
                    LastName = "Hemingway",
                    Genre = "Fiction",
                    DateOfBirth = new DateTimeOffset(new DateTime(1899, 7, 21)),
                    Books = new List<Book>()
                    {
                        new Book()
                        {
                            BookId = new Guid("10a2835a-ffcf-48e1-81a5-77dbe98be663"),
                            Title = "The Old Man and the Sea",
                            Description = "A tale of an old Cuban fisherman's journey, his supreme ordeal with a giant marlin, and his relentless, agonizing battle to death."
                        },
                        new Book()
                        {
                            BookId = new Guid("76717c6e-cf9c-46d6-b162-2ceabd14feb0"),
                            Title = "For Whom the Bell Tolls",
                            Description = "A novel set during the Spanish Civil War, detailing the experience of Robert Jordan, an American demolitions expert who lends his unique skills to the anti-fascist guerrilla forces."
                        }
                    }
                },
                new Author()
                {
                    AuthorId = new Guid("fdc646a7-4fb2-4244-930a-92204d109f18"),
                    FirstName = "F. Scott",
                    LastName = "Fitzgerald",
                    Genre = "Fiction",
                    DateOfBirth = new DateTimeOffset(new DateTime(1896, 9, 24)),
                    Books = new List<Book>()
                    {
                        new Book()
                        {
                            BookId = new Guid("143e2864-1561-41ea-a590-b51ded3b294c"),
                            Title = "The Great Gatsby",
                            Description = "A classic of twentieth-century literature, the novel tells the story of the mysteriously wealthy Jay Gatsby and his love for the beautiful Daisy Buchanan during the Roaring Twenties."
                        }
                    }
                },
                new Author()
                {
                    AuthorId = new Guid("14d4bbc9-e0bc-429b-b28f-6fef125f1f04"),
                    FirstName = "Virginia",
                    LastName = "Woolf",
                    Genre = "Modernist",
                    DateOfBirth = new DateTimeOffset(new DateTime(1882, 1, 25)),
                    Books = new List<Book>()
                    {
                        new Book()
                        {
                            BookId = new Guid("fac24c4b-14ab-46a6-8d1b-d78c73ef9d99"),
                            Title = "To the Lighthouse",
                            Description = "A pioneering work of modernist fiction, it is a novel centered on the Ramsays and their visits to the Isle of Skye in Scotland between 1910 and 1920."
                        },
                        new Book()
                        {
                            BookId = new Guid("365548b8-2eef-4c9a-8c6c-f92df320d488"),
                            Title = "Mrs Dalloway",
                            Description = "The novel details a day in the life of Clarissa Dalloway, a fictional high-society woman in post–First World War England."
                        }
                    }
                }
            };

            Authors.AddRange(authors);
            SaveChanges();
        }
    }
}
