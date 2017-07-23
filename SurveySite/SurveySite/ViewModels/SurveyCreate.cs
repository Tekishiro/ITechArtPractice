using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SurveySite.ViewModels
{
    public class SurveyCreate
    {
        [DisplayName("Question text")]
        [Required(ErrorMessage = "An question text is required")]
        [StringLength(1024)]
        public string QuestionText { get; set; }


        [DisplayName("Answer variant 1")]
        [Required(ErrorMessage = "At least 2 answers is required")]
        [StringLength(1024)]
        public string AnsverVariant1 { get; set; }

        [DisplayName("Answer variant 2")]
        [Required(ErrorMessage = "At least 2 answers is required")]
        [StringLength(1024)]
        public string AnsverVariant2 { get; set; }

        [DisplayName("Answer variant 3")]
        [StringLength(1024)]
        public string AnsverVariant3 { get; set; }

        [DisplayName("Answer variant 4")]
        [StringLength(1024)]
        public string AnsverVariant4 { get; set; }

        [DisplayName("Answer variant 5")]
        [StringLength(1024)]
        public string AnsverVariant5 { get; set; }

        [DisplayName("Answer variant 6")]
        [StringLength(1024)]
        public string AnsverVariant6 { get; set; }

        [DisplayName("Answer variant 7")]
        [StringLength(1024)]
        public string AnsverVariant7 { get; set; }

        [DisplayName("Answer variant 8")]
        [StringLength(1024)]
        public string AnsverVariant8 { get; set; }

        [DisplayName("Answer variant 9")]
        [StringLength(1024)]
        public string AnsverVariant9 { get; set; }
    }
}