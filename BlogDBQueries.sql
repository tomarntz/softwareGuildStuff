
--get blogs by tagId--
select *
from Blogs
	inner join Blogs_Tags
			on Blogs.BlogId = Blogs_Tags.BlogId
				inner join Tags
					on Blogs_Tags.TagId = Tags.TagId
where TagTitle = 'sword'

--get blogs by categoryId--
select *
from Blogs
	inner join Blog_Categories
		on Blogs.BlogId = Blog_Categories.BlogId
			inner join Categories
				on Blog_Categories.CategoryId = Categories.CategoryId
where Categories.CategoryId = 5 

--get most recent blog--
select top(1) BlogId
from Blogs
order by DatePosted desc

--get all tags--
select *
from Tags

--get all tags for a particular blog--
select TagTitle
from Blogs
	inner join Blogs_Tags
			on Blogs.BlogId = Blogs_Tags.BlogId
				inner join Tags
					on Blogs_Tags.TagId = Tags.TagId
where Blogs.BlogId = 1
						
--get owner/contributor info--
select FirstName, LastName, BlogId
	from AspNetUsers
		inner join AspNetUserRoles
			on AspNetUsers.Id = AspNetUserRoles.UserId
				inner join AspNetRoles
					on AspNetUserRoles.RoleId = AspNetRoles.Id
						inner join Blogs
							on AspNetUserRoles.RoleId = Blogs.UserId
--get all cats--
select *
	from Categories

--get particular cat by id--
select CategoryName
	from Categories
		where CategoryId = 2

--get all weapons from exhibit by exhibit id--
select *
from Weapons w
	inner join AspNetUsers a
		on w.UserId = a.Id