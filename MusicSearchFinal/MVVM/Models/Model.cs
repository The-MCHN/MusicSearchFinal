using MusicSearchFinal.DAL.Entities;
using MusicSearchFinal.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicSearchFinal.MVVM.Models
{
    class Model
    {
        public ObservableCollection<Band> Bands { get; set; } = new ObservableCollection<Band>();
        public ObservableCollection<Album> Albums { get; set; } = new ObservableCollection<Album>();
        public ObservableCollection<Belongs> Belongss { get; set; } = new ObservableCollection<Belongs>();
        public ObservableCollection<BelongsTo> BelongTo { get; set; } = new ObservableCollection<BelongsTo>();
        public ObservableCollection<Members> Members { get; set; } = new ObservableCollection<Members>();
        public ObservableCollection<Song> Songs { get; set; } = new ObservableCollection<Song>();
        public ObservableCollection<Users> Users{ get; set; } = new ObservableCollection<Users>();

        public Model()
        {
            //getting data from db to collecions
            var bands = BandsRepository.DownloadAllBands();
            foreach (var b in bands)
                Bands.Add(b);

            var albums = AlbumRepository.DownloadAllAlbums();
            foreach (var a in albums)
                Albums.Add(a);

            var belongs = BelongsRepository.DownloadAllBelongs();
            foreach (var bel in belongs)
                Belongss.Add(bel);
            

            var belongsTo = BelongsToRepository.DownloadAllBelongs();
            foreach (var bel in belongsTo)
                BelongTo.Add(bel);

            var members = MembersRepository.DownloadAllMembers();
            foreach (var mem in members)
                Members.Add(mem);

            var songs = SongRepository.DownloadAllSongs();
            foreach (var s in songs)
                Songs.Add(s);

            var users = UsersRepository.DownloadAllUsers();
            foreach (var u in users)
                Users.Add(u);




        }

        public bool IsUserInRepo(Users user) => Users.Contains(user);

        public bool IsBandInRepo(Band band) => Bands.Contains(band);
        public bool AddBandToDB(Band band)
        {
            if (!IsBandInRepo(band))
            {
                if (BandsRepository.AddBandToDB(band))
                {
                    Bands.Add(band);
                    return true;
                }
            }
            return false;
        }

        public bool DeleteBandFromDB(Band band)
        {
            if (IsBandInRepo(band))
            {
                if (BandsRepository.DeleteFromDB(band))
                {
                    Bands.Remove(band);
                    return true;
                }
            }
                return false;
        }

        public ObservableCollection<Members> GetBandsMembers(Band band)
        {
            var members = new ObservableCollection<Members>();
            foreach (var bel in Belongss)
            {
                if (bel.Name== band.Name)
                {
                    members.Add(GetMemberByID(bel.IDMember));
                }
            }

            return members;
        }

        public ObservableCollection<Album> GetAllBandAlbums(Band band)
        {
            var albums = new ObservableCollection<Album>();
            foreach (var b in BelongTo)
            {
                if (b.Name == band.Name)
                {
                    albums.Add(FindAlbumByID(b.IDAlbum));
                }
            }
            return new ObservableCollection<Album>(albums.Distinct());
        }

        public Album FindAlbumByID(int id)
        {
            foreach (var album in Albums)
            {
                if (album.ID == id)
                    return album;
            }
            return null;
        }
        public ObservableCollection<Band> GetBandOfMember(Members member)
        {
            var bands = new ObservableCollection<Band>();
            foreach (var b in Belongss)
            {
                if (b.IDMember == member.IDMember)
                {
                    bands.Add(FindBandByName(b.Name));
                }
            }

            return bands;
        }
        public Band FindBandByName(string name)
        {
            foreach (var b in Bands)
            {
                if (b.Name == name)
                    return b;
            }
            return null;
        }
        public Members GetMemberByID(int ID)
        {

            foreach (var member in Members)
            {
                if (member.IDMember == ID)
                    return member;
            }
                
            return null;
        }

        public ObservableCollection<Song> GetSongsFromAlbum(Album album)
        {
            var songs = new ObservableCollection<Song>();
            foreach (var b in BelongTo)
            {
                foreach (var s in Songs)
                {
                    if (s.IDSong == b.IDSong && album.ID == b.IDAlbum)
                    {
                        songs.Add(s);
                    }
                }
                // z albumu ID, z piosenki id i jeśli zgadzają się z tym samym obiektem przynależności 
            }
            return songs;
        }
    }
}
