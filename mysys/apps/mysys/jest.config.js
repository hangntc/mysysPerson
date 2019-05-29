module.exports = {
  name: "mysys",
  preset: "../../jest.config.js",
  coverageDirectory: "../../coverage/apps/mysys/",
  snapshotSerializers: [
    "jest-preset-angular/AngularSnapshotSerializer.js",
    "jest-preset-angular/HTMLCommentSerializer.js"
  ]
};
