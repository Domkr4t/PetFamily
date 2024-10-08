namespace PetFamily.Domain.Pets.VO
{
    public record PetPhotoList
    {
        public IReadOnlyList<PetPhoto> PetPhotos { get; }

        private PetPhotoList()
        {
            
        }

        public PetPhotoList(List<PetPhoto> petPhotos)
        {
            PetPhotos = petPhotos;
        }
    }
}
