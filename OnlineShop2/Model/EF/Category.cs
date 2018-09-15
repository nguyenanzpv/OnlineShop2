namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Category")]
    public partial class Category
    {
        public long ID { get; set; }

        [StringLength(250)]
        [DisplayName("Tên danh mục")]
        [Required(ErrorMessage ="Tên danh mục không được trống")]
        public string Name { get; set; }

        [StringLength(250)]
        [DisplayName("Tiêu đề")]
        public string MetaTitle { get; set; }

        [DisplayName("Danh mục cha")]
        public long? ParentID { get; set; }
        [DisplayName("Vị trí hiển thị")]
        public int? DisplayOrder { get; set; }

        [DisplayName("Tiêu đề seo")]
        [StringLength(250)]
        public string SeoTitle { get; set; }

        [DisplayName("Ngày tạo")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? CreatedDate { get; set; }

        [StringLength(250)]
        [DisplayName("Người tạo")]
        public string CreatedBy { get; set; }

        [DisplayName("Ngày thay đổi")]
        public DateTime? ModifiedDate { get; set; }

        [StringLength(250)]
        [DisplayName("Người thay đổi")]
        public string ModifiedBy { get; set; }

        [StringLength(250)]
        [DisplayName("Từ khóa")]
        public string MetaKeywords { get; set; }

        [StringLength(250)]
        [DisplayName("Mô tả")]
        public string MetaDescriptions { get; set; }

        [DisplayName("Trạng thái")]
        [Required(ErrorMessage ="Trạng thái không được để trống")]
        public bool Status { get; set; }

        [DisplayName("Hiển thị trang chủ")]
        [Required(ErrorMessage = "Hiển thị trang chủ không được để trống")]
        public bool ShowOnHome { get; set; }
    }
}
