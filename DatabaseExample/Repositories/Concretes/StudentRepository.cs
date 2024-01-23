using System;
using DatabaseExample.Core;
using DatabaseExample.Entities;
using DatabaseExample.Repositories.Abstracts;

namespace DatabaseExample.Repositories.Concretes;
public class StudentRepository:BaseRepository<Student>,IStudentRepository
{
	public StudentRepository()
	{
	}
}
