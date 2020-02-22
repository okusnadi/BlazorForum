﻿using BlazorForum.Data;
using BlazorForum.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlazorForum.Domain.Interfaces
{
    public interface IManageForumPosts
    {
        Task<List<ForumPost>> GetForumPostsAsync(int topicId);
        Task<bool> AddNewPostAsync(ForumPost newPost);
        Task<bool> DeletePostAsync(int postId);
    }

    public class ManageForumPosts : IManageForumPosts
    {
        private ApplicationDbContext _context;

        public ManageForumPosts(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ForumPost>> GetForumPostsAsync(int topicId) => 
            await new Data.Repository.ForumPosts(_context).GetForumPostsAsync(topicId);

        public async Task<bool> AddNewPostAsync(ForumPost newPost) => 
            await new Data.Repository.ForumPosts(_context).AddNewPostAsync(newPost);

        public async Task<bool> DeletePostAsync(int postId) =>
            await new Data.Repository.ForumPosts(_context).DeletePostAsync(postId);
    }
}
