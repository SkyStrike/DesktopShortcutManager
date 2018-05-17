using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace CustomLibraries
{
    public class UserFunctions
    {
        ///// <summary>
        ///// <para>Created By    : YUKUANG</para>
        ///// <para>Created Date  : 15 Oct 2009</para>
        ///// <para>Modified By   : -</para>
        ///// <para>Modified Date : -</para>
        ///// <para>---------------------------------------------------------------</para>
        ///// <para></para>
        ///// <para>Changes</para>
        ///// <para>---------------------------------------------------------------</para>
        ///// <para></para>
        ///// <para>Description</para>
        ///// <para>---------------------------------------------------------------</para>
        ///// Gets Icon from Icon Folder
        ///// </summary>
        ///// <param name="strIconFile"></param>
        ///// <returns></returns>
        //public static Icon GetIcon(string strIconFile)
        //{
        //    try
        //    {
        //        return new Icon(strIconFile);
        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //    }
        //}

        ///// <summary>
        ///// Gets the real application path of the program.
        ///// this will remove all parameters 
        ///// e.g. 
        ///// 
        ///// From "C:\program files\my program.exe" -MyParam
        ///// To "C:\program files\my program.exe"
        ///// 
        ///// </summary>
        ///// <param name="strApplicationPath"></param>
        ///// <returns></returns>
        //public static string GetApplicationPart(string strApplicationPath)
        //{
        //    string strResult = strApplicationPath;
        //    if (strResult[0] == '\"')
        //    {
        //        try
        //        {
        //            strResult = strResult.Substring(1, strResult.LastIndexOf("\"") - 1);
        //        }
        //        catch (Exception)
        //        {
        //            throw new Exception("Please ensure that the filepath is a valid path: " + strApplicationPath);
        //        }
        //    }
        //    return strResult;
        //}

        ///// <summary>
        ///// Gets the parameter part of the program.
        ///// this will remove all parameters 
        ///// e.g. 
        ///// 
        ///// From "C:\program files\my program.exe" -MyParam
        ///// To -MyParam
        ///// 
        ///// </summary>
        ///// <param name="strApplicationPath"></param>
        ///// <returns></returns>
        //public static string GetArgumentPart(string strApplicationPath)
        //{
        //    string strResult = strApplicationPath;

        //    if ((strResult.LastIndexOf("\"") + 1) == 0)
        //    {
        //        strResult = string.Empty;
        //    }
        //    else
        //    {
        //        strResult = strResult.Substring(strResult.LastIndexOf("\"") + 1);
        //    }

        //    return strResult;
        //}

        ///// <summary>
        ///// <para>Created By    : YUKUANG</para>
        ///// <para>Created Date  : 24 Oct 2009</para>
        ///// <para>Modified By   : -</para>
        ///// <para>Modified Date : -</para>
        ///// <para>---------------------------------------------------------------</para>
        ///// <para></para>
        ///// <para>Changes</para>
        ///// <para>---------------------------------------------------------------</para>
        ///// <para></para>
        ///// <para>Description</para>
        ///// <para>---------------------------------------------------------------</para>
        ///// Executes/Start the program
        ///// </summary>
        ///// <param name="strApplicationToExecute"></param>
        ////public static void ExecuteProgram(string strApplicationToExecute)
        ////{
        ////    //Exit if empty
        ////    if (string.IsNullOrEmpty(strApplicationToExecute)) return;

        ////    if (System.IO.File.Exists(GetApplicationPart(strApplicationToExecute)) || System.IO.Directory.Exists(GetApplicationPart(strApplicationToExecute)))

        ////        //Try to execute file
        ////        try
        ////        {
        ////            string strExecutable = GetApplicationPart(strApplicationToExecute);
        ////            string strArgs = GetArgumentPart(strApplicationToExecute);

        ////            System.Diagnostics.Process p = new System.Diagnostics.Process();
        ////            p.StartInfo = new System.Diagnostics.ProcessStartInfo(strExecutable, strArgs);

        ////            if (System.IO.File.Exists(strExecutable))
        ////            {
        ////                p.StartInfo.WorkingDirectory = System.IO.Directory.GetParent(strExecutable).FullName;
        ////            }

        ////            p.Start();
        ////        }
        ////        catch (Exception ex)
        ////        {
        ////            MessageBox.Show(ex.ToString());
        ////        }
        ////    else
        ////        MessageBox.Show("Application/Directory does not exists.\nPlease ensure that the folder/executable exist.");
        ////}


        ///// <summary>
        ///// <para>Created By    : YUKUANG</para>
        ///// <para>Created Date  : 24 Oct 2009</para>
        ///// <para>Modified By   : -</para>
        ///// <para>Modified Date : -</para>
        ///// <para>---------------------------------------------------------------</para>
        ///// <para></para>
        ///// <para>Changes</para>
        ///// <para>---------------------------------------------------------------</para>
        ///// <para></para>
        ///// <para>Description</para>
        ///// <para>---------------------------------------------------------------</para>
        ///// Opens the program parent directory
        ///// </summary>
        ///// <param name="strApplicationToExecute"></param>
        //public static void OpenProgramParent(string strApplicationToExecute)
        //{
        //    string strToExecute = CustomLibraries.UserFunctions.GetApplicationPart(strApplicationToExecute);

        //    //Exit if empty
        //    if (string.IsNullOrEmpty(strToExecute)) return;


        //    if (System.IO.File.Exists(strToExecute) || System.IO.Directory.Exists(strToExecute))

        //        //Try to execute file
        //        try
        //        {
        //            System.Diagnostics.Process.Start(System.IO.Path.GetDirectoryName(strToExecute));
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.ToString());
        //        }
        //    else
        //        MessageBox.Show("Application/Directory does not exists.\nPlease ensure that the folder/executable exist.");
        //}

        //public static string CreateUniqueFilename(string strFileSaveToLocation)
        //{
        //    if (!System.IO.File.Exists(strFileSaveToLocation))
        //    {
        //        return strFileSaveToLocation;
        //    }
        //    else
        //    {
        //        string folder = System.IO.Path.GetDirectoryName(strFileSaveToLocation);
        //        string filename = System.IO.Path.GetFileNameWithoutExtension(strFileSaveToLocation);
        //        string ext = System.IO.Path.GetExtension(strFileSaveToLocation);

        //        string final = string.Concat(System.IO.Path.Combine(folder, filename), ext);
        //        while (System.IO.File.Exists(final))
        //        {
        //            filename = System.IO.Path.GetFileNameWithoutExtension(strFileSaveToLocation) + "__" + DateTime.Now.Millisecond;
        //            final = string.Concat(System.IO.Path.Combine(folder, filename), ext);
        //        }
        //        return final;
        //    }
        //}
    }
}
