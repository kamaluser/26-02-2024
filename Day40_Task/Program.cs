using Day40_Task.Data;
using Day40_Task.Models;
using System;

SpeakerDao speakerDao = new SpeakerDao();
EventDao eventDao = new EventDao();

string opt;
do
{
    Console.WriteLine("---- Main Menu ----");
    Console.WriteLine("a. Speaker Operations");
    Console.WriteLine("b. Event Operations");
    Console.WriteLine("c. Exit");

    Console.WriteLine("Select Choice:");
    opt = Console.ReadLine();

    switch (opt)
    {
        case "a":

            string opt_a;
            do
            {
                Console.WriteLine("\n---- Speaker Menu ----\n");
                Console.WriteLine("1. Insert Speaker");
                Console.WriteLine("2. Delete Speaker");
                Console.WriteLine("3. Get Speaker By Id");
                Console.WriteLine("4. Get All Speakers");
                Console.WriteLine("5. Update Speaker");
                Console.WriteLine("0. Exit");

                Console.WriteLine("Select Operation:");
                opt_a = Console.ReadLine();

                switch (opt_a)
                {
                    case "1":

                        string name;
                        do
                        {
                            Console.WriteLine("Name: ");
                            name = Console.ReadLine();
                        } while (String.IsNullOrWhiteSpace(name));

                        string position;
                        do
                        {
                            Console.WriteLine("Position: ");
                            position = Console.ReadLine();
                        } while (String.IsNullOrWhiteSpace(position));

                        string company;
                        do
                        {
                            Console.WriteLine("Company: ");
                            company = Console.ReadLine();
                        } while (String.IsNullOrWhiteSpace(company));

                        string url;
                        do
                        {
                            Console.WriteLine("Image Url: ");
                            url = Console.ReadLine();
                        } while (String.IsNullOrWhiteSpace(url));
                        speakerDao.InsertSpeaker(name, position, company, url);
                        Console.WriteLine("Added Successfully");
                        break;
                    case "2":
                        string idStr;
                        int id;
                        do
                        {
                            Console.WriteLine("Id: ");
                            idStr = Console.ReadLine();
                        } while (!int.TryParse(idStr, out id) || id <= 0);
                        if (speakerDao.IsExistSpeaker(id))
                        {
                            speakerDao.DeleteSpeaker(id);
                            Console.WriteLine("Deleted Succesfully");
                        }
                        else
                        {
                            Console.WriteLine("Speaker is not exists in this ID");
                        }
                        
                        break;
                    case "3":
                        do
                        {
                            Console.WriteLine("Id: ");
                            idStr = Console.ReadLine();
                        } while (!int.TryParse(idStr, out id) || id <= 0);
                        if (speakerDao.IsExistSpeaker(id))
                        {
                            Speaker speaker = speakerDao.GetSpeakerById(id);
                            Console.WriteLine(speaker);
                        }
                        else
                        {
                            Console.WriteLine("Speaker is not exists in this ID");
                        }
                        
                        break;
                    case "4":
                        if (speakerDao.GetAllSpeakers().Count==0)
                        {
                            Console.WriteLine("There is not any Speaker");
                        }
                        else
                        {
                            foreach (var item in speakerDao.GetAllSpeakers())
                            {
                                Console.WriteLine(item);
                            }
                        }
                        break;
                    case "5":
                        do
                        {
                            Console.WriteLine("Id: ");
                            idStr = Console.ReadLine();
                        } while (!int.TryParse(idStr, out id) || id <= 0);

                        do
                        {
                            Console.WriteLine("Name: ");
                            name = Console.ReadLine();
                        } while (String.IsNullOrWhiteSpace(name));

                        do
                        {
                            Console.WriteLine("Position: ");
                            position = Console.ReadLine();
                        } while (String.IsNullOrWhiteSpace(position));

                        do
                        {
                            Console.WriteLine("Company: ");
                            company = Console.ReadLine();
                        } while (String.IsNullOrWhiteSpace(company));

                        do
                        {
                            Console.WriteLine("Image Url: ");
                            url = Console.ReadLine();
                        } while (String.IsNullOrWhiteSpace(url));
                        Speaker speaker1 = new Speaker();
                        speaker1.Id = id;
                        speaker1.Fullname = name;
                        speaker1.Position = position;
                        speaker1.Company = company;
                        speaker1.ImageURL = url;
                        if (speakerDao.IsExistSpeaker(id))
                        {
                            speakerDao.UpdateSpeaker(speaker1);
                            Console.WriteLine("Speaker Updated");
                        }
                        else
                        {
                            Console.WriteLine("Speaker is not exists in this ID");
                        }

                        break;
                    case "0":
                        Console.WriteLine("Finished");
                        break;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            } while (opt_a != "0");

            
            break;
        case "b":
            string opt_b;
            do
            {
                Console.WriteLine("\n---- Event Menu ----\n");
                Console.WriteLine("1. Insert Event");
                Console.WriteLine("2. Get Event By Id");
                Console.WriteLine("3. Get All Events");
                Console.WriteLine("4. Delete Event");
                Console.WriteLine("5. Add Speaker");
                Console.WriteLine("6. Remove Speaker");
                Console.WriteLine("0. Exit");

                Console.WriteLine("Select Operation");
                opt_b = Console.ReadLine();
                switch (opt_b)
                {
                    case "1":
                        string name;
                        do
                        {
                            Console.WriteLine("Name:");
                            name = Console.ReadLine();
                        } while (String.IsNullOrWhiteSpace(name));

                        string desc;
                        do
                        {
                            Console.WriteLine("Description:");
                            desc = Console.ReadLine();
                        } while (String.IsNullOrWhiteSpace(desc));

                        string address;
                        do
                        {
                            Console.WriteLine("Address:");
                            address = Console.ReadLine();
                        } while (String.IsNullOrWhiteSpace(address));

                        string startDateStr;
                        DateTime startDate;
                        do
                        {
                            Console.WriteLine("Start Date: ");
                            startDateStr = Console.ReadLine();
                        } while (!DateTime.TryParse(startDateStr, out startDate));


                        DateOnly startDateOnly = new DateOnly(startDate.Year, startDate.Month, startDate.Day);

                        string startTimeStr;
                        TimeOnly startTime;
                        do
                        {
                            Console.WriteLine("Start Time: ");
                            startTimeStr = Console.ReadLine();
                        } while (!TimeOnly.TryParse(startTimeStr, out startTime));


                        string endTimeStr;
                        TimeOnly endTime;
                        do
                        {
                            Console.WriteLine("End Time: ");
                            endTimeStr = Console.ReadLine();
                        } while (!TimeOnly.TryParse(endTimeStr, out endTime));

                        eventDao.InsertEvent(name, desc, address, startDateOnly, startTime, endTime);
                        Console.WriteLine("Added Successfully");
                        break;
                    case "2":
                        string idStr;
                        int id;
                        do
                        {
                            Console.WriteLine("Id: ");
                            idStr = Console.ReadLine();
                        } while (!int.TryParse(idStr, out id));

                        if (eventDao.IsExistEvent(id))
                        {
                            Event evn = eventDao.GetEventById(id);
                            Console.WriteLine(evn);
                        }
                        else
                        {
                            Console.WriteLine("Event is not exists in this ID");
                        }
                        
                        break;
                    case "3":
                        foreach (var item in eventDao.GetAllEvents())
                        {
                            Console.WriteLine(item);
                        }
                        break;
                    case "4":
                        do
                        {
                            Console.WriteLine("Id:");
                            idStr = Console.ReadLine();
                        } while (!int.TryParse(idStr, out id));
                        if (eventDao.IsExistEvent(id))
                        {
                            eventDao.DeleteEvent(id);
                            Console.WriteLine("Deleted Succesfully");
                        }
                        else
                        {
                            Console.WriteLine("Event is not exists in this ID");
                        }
                        
                        break;
                    case "5":
                        string eventIdStr;
                        int eventId;
                        do
                        {
                            Console.WriteLine("Event Id: ");
                            eventIdStr = Console.ReadLine();
                        } while (!int.TryParse(eventIdStr, out eventId) || eventId <= 0);

                        string speakerIdStr;
                        int speakerId;
                        do
                        {
                            Console.WriteLine("Speaker Id: ");
                            speakerIdStr = Console.ReadLine();
                        } while (!int.TryParse(speakerIdStr, out speakerId) || speakerId <= 0);

                        eventDao.AddSpeaker(eventId, speakerId);
                        break;
                    case "6":
                        do
                        {
                            Console.WriteLine("Event Id: ");
                            eventIdStr = Console.ReadLine();
                        } while (!int.TryParse(eventIdStr, out eventId) || eventId <= 0);

                        do
                        {
                            Console.WriteLine("Speaker Id: ");
                            speakerIdStr = Console.ReadLine();
                        } while (!int.TryParse(speakerIdStr, out speakerId) || speakerId <= 0);

                        eventDao.RemoveSpeaker(eventId, speakerId);
                        
                        break;
                    case "0":
                        Console.WriteLine("Finished");
                        break;
                    default:
                        Console.WriteLine("Invalid Choice!");
                        break;
                }
            } while (opt_b !="0");
            
            break;
        case "c":
            Console.WriteLine("Finished");
            break;
        default:
            Console.WriteLine("Invalid Choice!");
            break;
    }

} while (opt!="c");