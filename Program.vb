Imports System

Class Student
    Private studentId As Integer
    Private studentName As String
    Private age As Integer

    ' Constructor to initialize the student details
    Public Sub New(id As Integer, name As String, a As Integer)
        studentId = id
        studentName = name
        age = a
    End Sub

    ' Destructor to clean up resources
    Protected Overrides Sub Finalize()
        Console.WriteLine("Destructor Called for Student: " & studentName)
    End Sub

    ' Function to display student details
    Public Sub DisplayDetails()
        Console.WriteLine("Student ID: " & studentId)
        Console.WriteLine("Student Name: " & studentName)
        Console.WriteLine("Age: " & age)
    End Sub

    ' Function to get student ID
    Public Function GetId() As Integer
        Return studentId
    End Function
End Class

Module Program
    Sub Main(args As String())
        Dim choice As Integer = 0
        Dim students As New List(Of Student)()

        While choice <> 4
            Console.WriteLine("Menu:")
            Console.WriteLine("1. Add Student")
            Console.WriteLine("2. Display All Students")
            Console.WriteLine("3. Remove Student")
            Console.WriteLine("4. Exit")
            Console.Write("Enter your choice: ")
            choice = Convert.ToInt32(Console.ReadLine())

            Select Case choice
                Case 1
                    Console.Write("Enter Student ID: ")
                    Dim id As Integer = Convert.ToInt32(Console.ReadLine())
                    Console.Write("Enter Student Name: ")
                    Dim name As String = Console.ReadLine()
                    Console.Write("Enter Age: ")
                    Dim age As Integer = Convert.ToInt32(Console.ReadLine())

                    Dim student As New Student(id, name, age)
                    students.Add(student)
                    Console.WriteLine("Student Added Successfully!")
                Case 2
                    Console.WriteLine("Student Details:")
                    For Each s As Student In students
                        s.DisplayDetails()
                        Console.WriteLine()
                    Next
                Case 3
                    Console.Write("Enter Student ID to remove: ")
                    Dim idToRemove As Integer = Convert.ToInt32(Console.ReadLine())
                    Dim removed As Boolean = False

                    For i As Integer = 0 To students.Count - 1
                        If students(i).GetId() = idToRemove Then
                            students.RemoveAt(i)
                            Console.WriteLine("Student Removed Successfully!")
                            removed = True
                            Exit For
                        End If
                    Next

                    If Not removed Then
                        Console.WriteLine("Student with ID " & idToRemove & " not found!")
                    End If
                Case 4
                    Console.WriteLine("Exiting...")
                Case Else
                    Console.WriteLine("Invalid Choice! Please select again.")
            End Select
        End While
    End Sub
End Module
