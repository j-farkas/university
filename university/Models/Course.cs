using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace University.Models
{
  public class Course
  {
    private string _name;
    private int _id;
    private int _courseNumber;

    public Course()
    {

    }

    public Course(string name)
    {
      _name = name;
    }

    public int GetId()
    {
      return _id;
    }

    public void SetId(int id)
    {
      _id = id;
    }

    public string GetCourseName()
    {
      return _name;
    }

    public void SetCourseName(string name)
    {
      _name = name;
    }

    public string GetCourseNumber()
    {
      return _name;
    }

    public void SetCourseNumber(int _courseNumber)
    {
      _courseNumber = courseNumber;
    }

    public static Course Find(int check)
    {
      Course ret = new Course();
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM course where id = "+check+";";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      rdr.Read();
      if(rdr.IsDBNull(0) == false)
      {
        ret.SetId(rdr.GetInt32(0));
        ret.SetCourseName(rdr.GetString(1));
        ret.SetCourseNumber(rdr.GetInt32(2));
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return ret;
    }

    public static List<Course> GetAll()
    {
      List<Course> allCourses = new List<Course> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM course;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        Course newCourse = new Course();
        newCourse.SetId(rdr.GetInt32(0));
        newCourse.SetCourseName(rdr.GetString(1));
        newCourse.SetCourseNumber(rdr.GetInt32(2));
        allCourses.Add(newCourse);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allCourses;
    }

    public static void ClearAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM course;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
       conn.Dispose();
      }
    }

    // public static List<Course> GetCourses(int num)
    // {
    //
    //   List<Course> allCourses = new List<Course> {};
    //   MySqlConnection conn = DB.Connection();
    //   conn.Open();
    //   MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
    //   cmd.CommandText = @"SELECT * FROM `clients` WHERE `stylist` = "+num+" order by `hair` desc;";
    //   MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
    //   while(rdr.Read())
    //   {
    //     Course newCourse = new Course();
    //     newCourse.SetName(rdr.GetString(1));
    //     newCourse.SetId(rdr.GetInt32(0));
    //     newCourse.SetStylist(rdr.GetInt32(2));
    //     newCourse.SetHair(rdr.GetInt32(3));
    //     allItems.Add(newCourse);
    //   }
    //   conn.Close();
    //   if (conn != null)
    //   {
    //     conn.Dispose();
    //   }
    //   return allItems;
    // }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO `course` (`course_name`, `course_number`) VALUES ('"+_name"',"_courseNumber");";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public void Update(string field, string change)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"UPDATE `course` SET `"+field+"` = '"+change+"' WHERE `course`.`id` = "+_id+";";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public void Delete()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"delete from course WHERE `course`.`id` = "+_id+";";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

  }
}
