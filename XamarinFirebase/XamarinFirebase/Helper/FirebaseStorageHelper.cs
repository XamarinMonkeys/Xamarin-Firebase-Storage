﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Firebase.Storage;

namespace XamarinFirebase.Helper
{

    public class FirebaseStorageHelper
    {
        FirebaseStorage firebaseStorage = new FirebaseStorage("xamarinfirebase-****.appspot.com");

        public async Task<string> UploadFile(Stream fileStream,string fileName)
        {
            var imageUrl = await firebaseStorage
                .Child("XamarinMonkeys")
                .Child(fileName)
                .PutAsync(fileStream);
            return imageUrl;
        }

        public async Task<string> GetFile(string fileName)
        {
            return await firebaseStorage
                .Child("XamarinMonkeys")
                .Child(fileName)
                .GetDownloadUrlAsync();
        }
        public async Task DeleteFile(string fileName)
        {
           await firebaseStorage
                .Child("XamarinMonkeys")
                .Child(fileName)
                .DeleteAsync();
            
        }
    }
}
