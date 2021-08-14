// Http GET request
#r "nuget: Ply"

open FSharp.Control.Tasks
open System.Net.Http
open System.Net.Http.Json
open System.IO

module GetRequest =
    task {
        use client = new HttpClient()
        let! response =
            client.GetStringAsync("https://jsonplaceholder.typicode.com/todos/1")

        printfn "%A" response
    }
    |> Async.AwaitTask
    |> Async.RunSynchronously

type Post =
    { userId: int
      id: int
      title: string
      body: string }

module PostRequest =
    task {
    use client = new HttpClient()
    let partialPost =
        {| userId = 1
           title = "Sample"
           body = "Content" |}

    let! response =
        let url = "https://jsonplaceholder.typicode.com/posts"

        client.PostAsJsonAsync(url, partialPost)

    let! createdPost = response.Content.ReadFromJsonAsync<Post>()
    printfn $"Id: {createdPost.id} - Title: {createdPost.title}"
    }
    |> Async.AwaitTask
    |> Async.RunSynchronously
