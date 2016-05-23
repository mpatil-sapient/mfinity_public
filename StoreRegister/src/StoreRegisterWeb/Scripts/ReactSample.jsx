var CommentBox = React.createClass({
    render: function() {
     return (
          <div className="commentBox">
            Hello, world! I am a comment box 1.
          </div>

      );
    }
});
ReactDOM.render(
  <CommentBox />,
  document.getElementById('content')
);

var fakeData = [
      {
          "id": 0,
          "name": "Mayer Leonard",
          "city": "Kapowsin",
          "state": "Hawaii",
          "country": "United Kingdom",
          "company": "Ovolo",
          "favoriteNumber": 7
      },
      {
          "id": 1,
          "name": "Mayer Log",
          "city": "Kapowsin",
          "state": "Massachussetts",
          "country": "United States",
          "company": "Sapient",
          "favoriteNumber": 1
      },

];

ReactDOM.render(
    <Griddle results={fakeData }/>,
    document.getElementById('content-grid')
);