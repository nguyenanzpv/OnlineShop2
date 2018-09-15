using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;

namespace Model.Dao
{
    public class CategoryDao
    {
        OnlineShopDbContext db=null;
        public CategoryDao()
        {
            db = new OnlineShopDbContext();
        }

        public List<Category> ListAll()
        {
            return db.Categories.Where(x => x.Status == true).ToList();
        }

        public IEnumerable<Category> ListAllPaging(string searchString, int page, int pageSize)
        {

            //return db.Users.OrderByDescending(x=>x.CreatedDate).ToPagedList(page,pageSize);
            IQueryable<Category> model = db.Categories;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString) || x.MetaTitle.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }

        public Category GetById(string name)
        {
            return db.Categories.SingleOrDefault(x => x.Name == name);
        }

        public Category ViewDetail(int id)
        {
            return db.Categories.Find(id);
        }

        public bool ChangeStatus(long id)
        {
            var cate = db.Categories.Find(id);
            if (cate.Status)
            {
                cate.Status = false;
            }
            else
            {
                cate.Status = true;
            }
            db.SaveChanges();
            return cate.Status;
        }

        public long Insert(Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
            return category.ID;       
        }

        public bool Update(Category entity)
        {
            try
            {
                var cate = db.Categories.Find(entity.ID);
                if (!string.IsNullOrEmpty(entity.Name))
                {
                    cate.Name = entity.Name;
                }
                cate.MetaTitle = entity.MetaTitle;
                cate.ParentID = entity.ParentID;
                cate.DisplayOrder = entity.DisplayOrder;
                cate.SeoTitle = entity.SeoTitle;
                cate.CreatedDate = entity.CreatedDate;
                cate.CreatedBy = entity.CreatedBy;
                cate.ModifiedDate = entity.ModifiedDate;
                cate.ModifiedBy = entity.ModifiedBy;
                cate.MetaKeywords = entity.MetaKeywords;
                cate.MetaDescriptions = entity.MetaDescriptions;
                cate.Status = entity.Status;
                cate.ShowOnHome = entity.ShowOnHome;
                //user.ModifiedDate = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public bool Delete(int id)
        {
            try
            {
                var cate = db.Categories.Find(id);
                db.Categories.Remove(cate);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
