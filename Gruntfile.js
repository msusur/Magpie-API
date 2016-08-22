module.exports = function (grunt) {
  grunt.initConfig({
    exec: {
      build_source: {
        cmd: 'dotnet restore source/Magpie.Library && dotnet build source/Magpie.Library'
      },
      build_tests: {
        cmd: 'dotnet restore tests/Magpie.Library.Tests && dotnet build tests/Magpie.Library.Tests/'
      },
      run_tests: {
        cmd: 'dotnet test tests/Magpie.Library.Tests/'
      }
    }
  });

  grunt.loadNpmTasks('grunt-exec');

  grunt.registerTask('default', 'exec');
};
