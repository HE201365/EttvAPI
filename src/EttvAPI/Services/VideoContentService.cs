using System;
using System.Collections.Generic;
using EttvAPI.Data.Models;
using EttvAPI.Models;
using EttvAPI.Repos.Interfaces.Repositories;
using EttvAPI.Repos.Repositories;
using EttvAPI.Services.Communication;
using EttvAPI.Services.Interfaces;

namespace EttvAPI.Services
{
    public class VideoContentService : IVideoContentService
    {
        private readonly UnitOfWork _unitOfWork;

        public VideoContentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork as UnitOfWork;
        }
        public IEnumerable<VideoContent> List()
        {
            return _unitOfWork.videoContentRepository.GetAll();
        }

        public VideoContentResponce Save(VideoContent videoContent)
        {
            try
            {
                _unitOfWork.videoContentRepository.Add(videoContent);
                _unitOfWork.Commit();
                return new VideoContentResponce(videoContent);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return new VideoContentResponce($"An error occurred when saving the videoContent: {ex.Message}");
            }
        }

        public VideoContentResponce Update(string videoId, VideoContent videoContent)
        {
            throw new NotImplementedException();
        }

        public VideoContentResponce Delete(string videoId)
        {
            throw new NotImplementedException();
        }
    }
}
