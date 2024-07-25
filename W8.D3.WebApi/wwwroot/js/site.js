let basePath = '/api/contacts'
const token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiTmVsbG8iLCJzdWIiOiJOZWxsbyIsImp0aSI6ImQzODgxOTI3LTc5ZGYtNDhiYi1hMDUyLTkyN2QzZWUzM2QyOSIsImV4cCI6MTc1MzQzNDIyMywiaXNzIjoiZXBpY29kZS5pdCIsImF1ZCI6ImVwaWNvZGUuaXQifQ.eHRmdUvDZoZgqSuW-_BobBTkCR6Ker0CbJBucnX_HXU"
$(() => {
    getContacts()

    $("#insert").on('click', () => {
        let name = $("#name").val()
        let phone = $("#phone").val()
        let contact = { "name": `${name}`, "phone": `${phone}` }
        $.ajax({
            url: `${basePath}`,
            method: 'post',
            headers: { 'Authorization': `Bearer ${token}`},
            contentType: 'application/json',
            data: JSON.stringify(contact),
            success: () => getContacts(),
            error: (e) => console.log(e)
        })
    })
})
function getContacts() {
    $.ajax({
        url: `${basePath}`,
        method: 'get',
        success: (data) => { 
            let ul = $("#contact-list ul")
            ul.empty()
            $(data).each((_, contact) => {
                let textSpan = $('<span>').text(`${contact.name} - ${contact.phone}`)
                let deleteBtn = $("<button type='button'>").attr('data-id', contact.id).text('Elimina')
                let li = $('<li>')
                textSpan.appendTo(li)
                deleteBtn.appendTo(li)
                li.appendTo(ul)

                $(deleteBtn).on('click', () => {
                    $.ajax({
                        url: `${basePath}/${contact.id}`,
                        method: 'delete',
                        success: getContacts()
                    })
                })
            })
        },
        error: (e) => console.log(e)
    })
}