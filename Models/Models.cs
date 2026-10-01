using System;
using System.Collections.Generic;
namespace UCSPyayStudentRegistration.Models {
 public class Student { public int StudentId; public string StudentName,EnglishName,Gender,Nrc,Phone,Email,PhotoPath,UniversityRollNo,Major,AcademicYear,Address; public DateTime DateOfBirth; public int Year; }
 public class Parent { public int StudentId; public string FatherName,FatherNrc,FatherPhone,FatherOccupation,FatherAddress,MotherName,MotherNrc,MotherPhone,MotherOccupation,MotherAddress; }
 public class Guardian { public int StudentId; public string Name,Nrc,Relationship,Occupation,Phone,Address; }
 public class RegistrationApplication { public int ApplicationId,StudentId,Year,CorrectionVersion; public string ApplicationNo,AcademicYear,Status,CorrectionReason,RejectReason; public decimal RegistrationFee; public DateTime SubmittedDate,LastUpdated; }
 public class RegistrationDocument { public string DocumentType,FileName,FilePath,VerificationStatus; public long FileSize; }
 public class Payment { public decimal RequiredAmount,PaidAmount; public string Method,TransactionId,ReceiptPath,Status; public DateTime PaymentDate; }
 public class WizardData { public Student Student=new Student(); public Parent Parent=new Parent(); public Guardian Guardian=new Guardian(); public RegistrationApplication Application=new RegistrationApplication(); public List<RegistrationDocument> Documents=new List<RegistrationDocument>(); public Payment Payment=new Payment(); public string SeatOrRoll; }
}
