namespace Educational_Medical_platform.Helpers
{
    public static class StorageInfo
    {
        public static string BooksImagesPath { get; } = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", "Book");

        public static long MaxImageSize { get; } = 2 * 1024 * 1024;  // 2 MB
        public static long MaxVideoSize { get; } = 2L * 1024 * 1024 * 1024; // 2 GB in bytes
    }
}