export interface Movie {
    id: number;
    title: string;
    releaseDate: Date;
    genre: any [];
    price: number;
    rating: number;
    director: string;
    description: string;
    photourl: string;
    ticketPrice: number;
    country: string;
}

export interface APIResponse {
    statusCode: number;
    message: string;
    success: boolean;
    data: any[];
}