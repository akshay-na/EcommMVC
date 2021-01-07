using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EcommMVC.Views.ViewModels
{
  public class FileUpload
  {


    [DataType(DataType.Upload)]
    [Display(Name = "Upload File")]
    [Required(ErrorMessage = "Please choose file to upload.")]
    public string file { get; set; }

    public FileUpload()
    {

    }

    public override bool Equals(object obj)
    {
      return obj is FileUpload upload &&
             file == upload.file;
    }

    public override int GetHashCode()
    {
      return 1455438011 + EqualityComparer<string>.Default.GetHashCode(file);
    }
  }
}